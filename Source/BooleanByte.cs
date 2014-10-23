using System;

namespace BoolByte
{
    /// <summary>
    /// Wrapper for a single byte that can be addressed on a per-bit level.
    /// </summary>
    /// <remarks>
    /// Useful for memory critical applications, such as tile data in a game, where large amounts of boolean values
    /// need to be stored, without using an entire byte for each. This allows a single byte to contain 8 easily addressable
    /// boolean values.
    /// 
    /// Copyright (c) 2014 Cyral
    /// </remarks>
    /// <example>
    /// BooleanByte data = new BooleanByte();
    /// data[2] = true; //Underlying byte now equals 0010000
    /// data[7] = true; //Underlying byte now equals 0010001
    /// bool foo = data[2]; //True
    /// bool bar = data[1]; //False
    /// </example>
    /// <see cref="https://github.com/Cyral/BooleanByte/"/>
    public struct BooleanByte
    {
        /// <summary>
        /// Gets or sets the boolean value (bit) at the index
        /// </summary>
        /// <param name="index">The bit of the byte (0-7)</param>
        /// <returns>The boolean value of the bit</returns>
        public bool this[int index]
        {
            get
            {
                return GetBit(index);
            }
            set
            {
                SetBit(index, value);
            }
        }

        /// <summary>
        /// The raw underlying byte that is used for containg each bit
        /// </summary>
        public byte Raw
        {
            get { return data; }
            set { data = value; }
        }
        private byte data; //Backing store

        /// <summary>
        /// Sets the boolean value to the specified index
        /// </summary>
        /// <param name="index">The bit of the byte to set (0-7)</param>
        /// <param name="value">The boolean value to set the bit as</param>
        public void SetBit(int index, bool value)
        {
            //Validation
            if (index >= 8 && index < 0)
                throw new ArgumentOutOfRangeException("Index must refer to a bit, 0-7.");

            if (value)
            {
                //Left-shift 1, then bitwise OR
                data = (byte)(data | (1 << index));
            }
            else
            {
                //Left-shift 1, then take complement, then bitwise AND
                data = (byte)(data & ~(1 << index));
            }
        }

        /// <summary>
        /// Gets the bit at the specified index
        /// </summary>
        /// <param name="index">The bit of the byte to return (0-7)</param>
        /// <returns>The boolean value of the bit</returns>
        public bool GetBit(int index)
        {
            //Validation
            if (index >= 8 && index < 0)
                throw new ArgumentOutOfRangeException("Index must refer to a bit, 0-7.");

            //Left-shift 1, then bitwise AND, then check for non-zero
            return ((data & (1 << index)) != 0);
        }

        public override bool Equals(object obj)
        {
            if (obj is BooleanByte)
                return data == ((BooleanByte)obj).data;
            return false;
        }

        public override int GetHashCode()
        {
            return data.GetHashCode();
        }
    }
}
