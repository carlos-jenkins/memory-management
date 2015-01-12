using System.Collections.Generic;

namespace MemoryManagement
{
    class HeapNode
    {
        private int size;
        private int lastRef;
        private List<Block> blocks;

        public HeapNode(int size, int lastRef, Block initialBlock)
        {
            this.size = size;
            this.lastRef = lastRef;
            
            this.blocks = new List<Block>();
            this.blocks.Add(initialBlock);
        }

        public bool ContainsSize(int size)
        {
            return this.size == size;
        }

        public Block GetHead()
        {
            Block head = blocks.Find(delegate(Block block)
            {
                return !block.InUse; //Every block in the heap SHOULDN'T be in use.
            });

            blocks.Remove(head);

            return head;
        }

        public bool Empty()
        {
            return blocks.Count == 0;
        }

        public override string ToString()
        {
            return string.Format("\t{0}\t\t{1}\t{2}", size, lastRef, blocks.Count);
        }

        //Getters ans setters
        public int Size
        {
            //set { LastRef = value; }
            get { return size; }
        }

        public int LastRef
        {
            set { lastRef = value; }
            get { return lastRef; }
        }

        public List<Block> Blocks
        {
            //set { Blocks = value; }
            get { return blocks; }
        }
    }
}
