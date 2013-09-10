GeoDataSource
=============
GeoDataSource is a .NET Class Library based off of the data from http://www.geonames.org.  We only capture the Country and Province level of information, which ends up taking a 1.2GB file down to 1.7MB.  Useful and practical for most web based input forms.

It has two methods of operation:

1. To automatically download, parse and convert the geonames.org data into a binary serialized data stream on disk.  This file will be used in subsequent calls for queries.  Keep in mind that this will download close to 400MB of data, and will require about 1.2GB of disk space during the conversion process.  It will check to make sure it has read and write access to the disk first, if it does it will update otherwise it will skip the update.  It will also delete all files after it is done, other than two:  The updated GeoDataSource.dat file, and a GeoDataSource-LastModified.txt file which simply contains a timestamp of when the data was updated.

Also during the update process, we will issue a HEAD request to the remote server and make sure that it is in fact new before performing any update; based on what the server returns in its Last-Modified header.


2. To consume the binary serialized stream for queries.

See unit tests for usage.


Building
========
When building, make sure you run the update process first, to get a fresh copy of the GeoDataSource.dat file.  Replace the file in the project, and then build.  This is the default set of data that the DLL will use for queries.  This also makes the forced update unnecessary until you really want it.

Data Available
==============
Countries
Provinces
TimeZone Information
Feature Codes (detailed descriptions about each item)
