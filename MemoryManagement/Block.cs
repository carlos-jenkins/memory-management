using System;

namespace MemoryManagement
{	
	public class Block
	{	
		private int size;
        private int id = -1;
		private bool inUse = false;
		
        public Block(int Size)
        {
            this.Size = Size;
        }

        //Getters and setters
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool InUse
        {
            get { return inUse; }
            set { inUse = value; }
        }
	}
}
