BooleanByte
===========

A wrapper for a single byte that can be addressed on a per-bit level.

Useful for memory critical applications, such as tile data in a game, where large amounts of boolean values
need to be stored, without using an entire byte for each. This allows a single byte to contain 8 easily addressable
boolean values.
