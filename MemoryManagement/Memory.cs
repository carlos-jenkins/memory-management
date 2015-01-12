using System;
using System.Collections.Generic;

namespace MemoryManagement
{
    class Memory
    {
        private static char[] delimiters = {' ', '\t'};

        //Memory status
        private int totalMemory = 0;
        private int freeMemory = 0;
        private int unassignedMemory = 0;
        
        private int allocations = 0;        //Variable t
        private int allocationsMemory = 10; //Variable T

        //Memory implementation.
        private List<Block> physicalMemory = new List<Block>();
        private List<HeapNode> heap = new List<HeapNode>();
        
        //ID control
        private List<int> ids = new List<int>();

        //Statistics manager.
        private List<int[]> statistics = new List<int[]>();

        public bool Allocate(int requestedSize, int id)   //Id MUST be valid, verify with ExistsId()
        {
            //Register the allocation request in the statistics
            int[] blockStatistic = statistics.Find(delegate(int[] evaluatedArray)
            {
                return evaluatedArray[0] == requestedSize;
            });

            if (blockStatistic != null)
            {
                blockStatistic[1]++;
            }
            else
            {
                statistics.Add(new int[2] { requestedSize, 1 });
            }


            //Assumes allocation is succefull
            allocations++;

            //Search in the heap for a list of the requested size.
            HeapNode heapNode = heap.Find(delegate(HeapNode evaluatedHeapNode)
                    {
                        return evaluatedHeapNode.ContainsSize(requestedSize);
                    });

            //Result block
            Block searchedBlock = null;

            if (heapNode != null)
            {
                heapNode.LastRef = allocations;
                searchedBlock = heapNode.GetHead();

                if (heapNode.Empty())
                {
                    heap.Remove(heapNode);
                    heap.TrimExcess();
                }
            }
            else
            {
                //Sequencial search: first-fit method
                searchedBlock = physicalMemory.Find(delegate(Block block)
                {
                    return (block.Size >= requestedSize) && (!block.InUse);
                });

            }

            //No block avalaible.
            if (searchedBlock == null)
            {
                allocations--;
                return false;
            }
            //A block of the requested size or greater was found.
            else
            {
                //Dispose all heapNodes for which t - heapNode.lastRef > T;
                List<HeapNode> toDispose = heap.FindAll(delegate(HeapNode evaluatedHeapNode)
                {
                    return ((allocations - evaluatedHeapNode.LastRef) > allocationsMemory);
                });

                toDispose.ForEach(delegate(HeapNode unusedHeapNode)
                {
                    heap.Remove(unusedHeapNode);
                });

                //If the block is bigger than the requested size.
                if (searchedBlock.Size > requestedSize)
                {
                    int index = physicalMemory.IndexOf(searchedBlock);
                    int remaining = searchedBlock.Size - requestedSize;

                    //Creates a new block of the remaining size.
                    searchedBlock.Size = requestedSize;
                    physicalMemory.Insert(index + 1, new Block(remaining));
                }

                searchedBlock.InUse = true;
                searchedBlock.Id = id;

                //Register the ID
                ids.Add(id);

                //Update the free space
                freeMemory -= requestedSize;

                return true;
            }

        }

        public bool Dispose(int id)
        {
            if (ExistsId(id))
            {
                Block disposedBlock = physicalMemory.Find(delegate(Block block)
                {
                    return block.Id == id;
                });

                disposedBlock.InUse = false;
                disposedBlock.Id = -1;

                //Update the memory.
                freeMemory += disposedBlock.Size;

                ids.Remove(id);
                AddToHeap(disposedBlock);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void DefragmentHighLevel()
        {
            List<Block> inUse = new List<Block>();
            List<Block> notInUse = new List<Block>();

            physicalMemory.ForEach(delegate(Block evaluatedBlock)
            {
                if (evaluatedBlock.InUse)
                {
                    inUse.Add(evaluatedBlock);
                }
                else 
                {
                    notInUse.Add(evaluatedBlock);
                }
            });

            inUse.AddRange(notInUse);
            physicalMemory = inUse;
        }

        public void DefragmentSystem()
        {
            physicalMemory.Sort(delegate(Block block1, Block block2)
            {
                if (block1.InUse && !block2.InUse)
                    return -1;
                if (!block1.InUse && block2.InUse)
                    return 1;
                else
                    return 0;
            });
        }

        public void DefragmentLowLevel()
        {
            //Space reclamation process - Sweep algorithm.
            //The mark algorithm is unnecessary because block object already have a mark : "InUse".
            List<Block> availList = new List<Block>();
            physicalMemory.ForEach(delegate(Block evaluatedBlock)
            {
                if (!evaluatedBlock.InUse)
                {
                    availList.Add(evaluatedBlock);
                }
            });

            //Compactation process - The QuickSort like algorithm is not necessary 
            //because Block objects don't have a tail and head pointers. 
            //Just moving all the avalaible blocks to the end of the memory 
            //(Assuming that in a low level implementation, used blocks will be copied to the unallocated block).
            availList.ForEach(delegate(Block evaluatedBlock)
            {
                physicalMemory.Remove(evaluatedBlock);
                physicalMemory.Add(evaluatedBlock);
            });

        }

        public bool Reorganize()
        {
            //No statistics file, no allocations has been made, unable to reorganize memory.
            if (statistics.Count == 0)
                return false;

            List<Block> freeBlocks = new List<Block>();

            physicalMemory.ForEach(delegate(Block evaluatedBlock)
            {
                if (!evaluatedBlock.InUse)
                {
                    freeBlocks.Add(evaluatedBlock);
                }
            });

            freeBlocks.ForEach(delegate(Block evaluatedBlock)
            {
                unassignedMemory += evaluatedBlock.Size;
                physicalMemory.Remove(evaluatedBlock);
            });

            int originalUnassignedMemory = unassignedMemory;

            statistics.ForEach(delegate(int[] evaluatedArray)
            {
                float percent = ((float)evaluatedArray[1] / ((allocations == 0) ? 1 : (float)allocations));
                int memoryForThisBlocks = (int)(originalUnassignedMemory * percent);
                
                int size = evaluatedArray[0];

                while ((memoryForThisBlocks - size) >= 0)
                {
                    CreateBlock(size);
                    memoryForThisBlocks -= size;
                }
            });

            if (unassignedMemory > 0)
            {
                CreateBlock(unassignedMemory);
            }

            GenerateHeap();

            return true;
        }

        public string GenerateReport(bool includeHead)
        {
            DateTime eventTime = DateTime.Now;

            string result = "Memory simulation report:" +
                System.Environment.NewLine + 
                "\tDate: " +
                eventTime.ToLongDateString() +
                System.Environment.NewLine + 
                "\tTime: " + 
                eventTime.ToLongTimeString() + 
                System.Environment.NewLine + 
                "\tSequence\tSize\tStatus" +
                System.Environment.NewLine +
                "\t-----------------------------------------------------------" +
                System.Environment.NewLine
                ;

            int count = 0;

            physicalMemory.ForEach(delegate(Block block)
            {
                result += "\t" + count + "\t\t" + block.Size + "\t" + (block.InUse?"Occupied":"Free") + System.Environment.NewLine;
                count++;
            });

            result += 
                "\t-----------------------------------------------------------" +
                System.Environment.NewLine;

            if (includeHead)
            {
                result +=
                    System.Environment.NewLine +
                    "\tSize\tLast reference\tBlocks" +
                    System.Environment.NewLine +
                    "\t-----------------------------------------------------------" +
                    System.Environment.NewLine;

                heap.ForEach(delegate(HeapNode heapNode)
                {
                    result += heapNode.ToString() + System.Environment.NewLine;
                });

                result +=
                    "\t-----------------------------------------------------------" +
                    System.Environment.NewLine;

            }

            return result;
        }

        public bool Load(System.IO.StreamReader Reader)
        {
            if (Reader.Peek() != -1)
            {
				//Reads the total memory avalaible.
                String[] totalMemoryLine = Reader.ReadLine().Trim().Split(delimiters);
                if (totalMemoryLine.Length != 1)
                {
                    return false;
                }

                try
                {
                    totalMemory = Int32.Parse(totalMemoryLine[0]);
                    freeMemory = totalMemory;
                    unassignedMemory = totalMemory;
                }
                catch (FormatException)
                {
                    return false;
                }

				//Reads the blocks definition structure.
                while (Reader.Peek() > -1)
                {
                    String[] line = Reader.ReadLine().Trim().Split(delimiters);
                    if (line.Length != 2)
                    {
                        return false;
                    }

                    try
                    {
                        for (int totalBlocks = Int16.Parse(line[0]), 
                            blockSize = Int16.Parse(line[1]); 
                            totalBlocks > 0; 
                            totalBlocks--)
                        {
                            if (!CreateBlock(blockSize))
                            {
                                totalBlocks = 0;
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }

                if (unassignedMemory > 0)
                {
                    CreateBlock(unassignedMemory);
                }

                //Generates the new heap
                GenerateHeap();

                return true;
            }
            else
            {
                return false;
            }
        }

        //Utilities
        public bool ExistsId(int id)
        {
            return ids.Exists(delegate(int evaluatedId)
            {
                return evaluatedId == id;
            });
        }

        private void GenerateHeap()
        {
            //Clean the heap - just in case
            heap.Clear();

            //Create the heap
            physicalMemory.ForEach(delegate(Block block)
            {
                AddToHeap(block);
            });
        }

        private void AddToHeap(Block block)
        {
            HeapNode heapNode = heap.Find(delegate(HeapNode evaluatedHeapNode)
            {
                return evaluatedHeapNode.Size == block.Size;
            });

            if (heapNode != null)
            {
                heapNode.Blocks.Add(block);
            }
            else
            {
                heap.Add(new HeapNode(block.Size, allocations, block));
            }
        }

	    private bool CreateBlock(int Size)
	    {
            if ((unassignedMemory - Size) < 0)
		    	return false;

            physicalMemory.Add(new Block(Size));

            unassignedMemory -= Size;
		
		    return true;
	    }

        //Getters and setters
        public int Blocks
        {
            get { return physicalMemory.Count; }
        }
        public List<Block> PhysicalMemory
        {
            get { return physicalMemory; }
        }
        public int TotalMemory
        {
            get { return totalMemory; }
        }
        public int FreeMemory
        {
            get { return freeMemory; }
        }
	}
}
