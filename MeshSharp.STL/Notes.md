# Ascii STL format

An ASCII STL file begins with the line
```
solid name
```
where **name** is an optional string (though if name is omitted there must still be a space after solid). The file continues with any number of triangles, each represented as follows:
```
facet normal ni nj nk
    outer loop
        vertex v1x v1y v1z
        vertex v2x v2y v2z
        vertex v3x v3y v3z
    endloop
endfacet
```

where each n or v is a floating-point number in sign-mantissa-"e"-sign-exponent format, e.g., "2.648000e-002". The file concludes with
```
endsolid name
```
The structure of the format suggests that other possibilities exist (e.g., facets with more than one "loop", or loops with more than three vertices). In practice, however, all facets are simple triangles.

White space (spaces, tabs, newlines) may be used anywhere in the file except within numbers or words. The spaces between "facet" and "normal" and between "outer" and "loop" are required.

# Binary STL format

Because ASCII STL files can be very large, a binary version of STL exists. A binary STL file has an 80-character header (which is generally ignored, but should never begin with "solid" because that may lead some software to assume that this is an ASCII STL file). Following the header is a 4-byte little-endian unsigned integer indicating the number of triangular facets in the file. Following that is data describing each triangle in turn. The file simply ends after the last triangle.

Each triangle is described by twelve 32-bit floating-point numbers: three for the normal and then three for the X/Y/Z coordinate of each vertex – just as with the ASCII version of STL. After these follows a 2-byte ("short") unsigned integer that is the "attribute byte count" – in the standard format, this should be zero because most software does not understand anything else.

Floating-point numbers are represented as IEEE floating-point numbers (the same format as floats in .NET) and are assumed to be little-endian, although this is not stated in documentation.

# References

* https://en.wikipedia.org/wiki/STL_(file_format)
* http://paulbourke.net/dataformats/stl/
* http://www.fabbers.com/tech/STL_Format