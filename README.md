GeoDataSource
=============
GeoDataSource is a .NET Class Library based off of the data from http://www.geonames.org 

It has two methods of operation:

1. To automatically download, parse and convert the geonames.org data into a binary serialized data stream on disk.  This file will be used in subsequent calls for queries.

2. To consume the binary serialized stream for queries.

See unit tests for usage.


Building
========
When building, make sure you run the update process first, to get a fresh copy of the GeoDataSource.dat file.  Replace the file in the project, and then build.  This is the default set of data that the DLL will use for queries.  This also makes the forced update unnecessary until you really want it.