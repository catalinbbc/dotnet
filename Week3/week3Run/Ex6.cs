using System;
using System.Collections.Generic;
using System.Text;

namespace week3Run
{
    class BitArray64
    {
        private long value;


        public BitArray64(long number)
        {
            value = number;
        }
        // Indexer declaration
        public long this[int index]
        {
            get
            {
                if (index >= 0 && index <= 63)
                {
                    // Check the bit at position index
                    if ((value & (1 << index)) == 0)
                        return 0;
                    else
                        return 1;
                }
                else
                {
                    throw new IndexOutOfRangeException(
                    String.Format("Index {0} is invalid!", index));
                }
            }
            set
            {
                if (index < 0 || index > 63)
                    throw new IndexOutOfRangeException(
                       String.Format("Index {0} is invalid!", index));
                if (value < 0 || value > 1)
                    throw new ArgumentException(
                       String.Format("Value {0} is invalid!", value));
                // Clear the bit at position index
                value &= ~(long)(1 << index);
                // Set the bit at position index to value
                value |= (long)(value << index);
            }
        }
    }
}
