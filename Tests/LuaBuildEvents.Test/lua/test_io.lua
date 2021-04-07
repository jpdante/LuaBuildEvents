require("lua.io")

local function isempty(s)
  return s == nil or s == ''
end

test_count = 0

Directory.createDirectory("test-folder")

print("-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n")

if Directory.exists("test-folder") == true then
print("# 1 - Create directory 'test-folder'                V\n")
test_count = test_count + 1
else
print("# 1 - Create directory 'test-folder'                X\n")
end

fileStream = File.create("test-folder/test-file.txt")

if File.exists("test-folder/test-file.txt") == true then
print("# 2 - Create file 'test-folder/test-file.txt'       V\n")
test_count = test_count + 1
else
print("# 2 - Create file 'test-folder/test-file.txt'       X\n")
end

if isempty(fileStream) then
print("# 3 - Open file 'test-folder/test-file.txt'         X\n")
else
print("# 3 - Open file 'test-folder/test-file.txt'         V\n")
test_count = test_count + 1
end

writer = StreamWriter.New(fileStream)
writer.write("Hello World!")
writer.flush()
writer.close();
writer.dispose();
fileStream.dispose();

fileStream = File.open("test-folder/test-file.txt", FileMode.Open)

if isempty(fileStream) then
print("# 4 - Open file 'test-folder/test-file.txt'         X\n")
else
print("# 4 - Open file 'test-folder/test-file.txt'         V\n")
test_count = test_count + 1
end

reader = StreamReader.New(fileStream)
data = reader.readToEnd()
reader.close();
reader.dispose();
fileStream.dispose();

if data == "Hello World!" then
print("# 5 - Read/Write file 'test-folder/test-file.txt'   V\n")
test_count = test_count + 1
else
print("# 5 - Read/Write file 'test-folder/test-file.txt'   X\n")
end

if Path.combine("test-folder/", "test-file.txt") == "test-folder/test-file.txt" then
print("# 6 - Path combine 'test-folder/' + 'test-file.txt' V\n")
test_count = test_count + 1
else
print("# 6 - Path combine 'test-folder/' + 'test-file.txt' X\n")
end

directoryInfo = DirectoryInfo.New("test-folder")
if directoryInfo.name == "test-folder" then
print("# 7 - Directory info 'test-folder'                  V\n")
test_count = test_count + 1
else
print("# 7 - Directory info 'test-folder'                  X\n")
end

fileInfo = FileInfo.New("test-folder/test-file.txt")
if fileInfo.name == "test-file.txt" then
print("# 7 - File info 'test-folder/test-file.txt'         V\n")
test_count = test_count + 1
else
print("# 7 - File info 'test-folder/test-file.txt'         X\n")
end

require("lua.io.compression")

if File.exists("testzip.zip") == true then
File.delete("testzip.zip")
end

ZipFile.createFromDirectory("test-folder", "testzip.zip")

if File.exists("testzip.zip") == true then
print("# 8 - Create zip 'testzip.zip'                      V\n")
test_count = test_count + 1
else
print("# 8 - Create zip 'testzip.zip'                      X\n")
end

Directory.createDirectory("test-folder2")

ZipFile.extractToDirectory("testzip.zip", "test-folder2/", true)

if File.exists("test-folder2/test-file.txt") == true then
print("# 9 - Extract zip 'testzip.zip'                     V\n")
test_count = test_count + 1
else
print("# 9 - Extract zip 'testzip.zip'                     X\n")
end

fileStream = File.create("test-folder/test-gzip.txt")
gzip = GZipStream.New(fileStream, CompressionMode.Compress)
writer = StreamWriter.New(gzip)
writer.write("Test GZip ;)")
writer.flush()
writer.close();
writer.dispose();
gzip.dispose();
fileStream.dispose();

fileStream = File.open("test-folder/test-gzip.txt", FileMode.Open)
gzip = GZipStream.New(fileStream, CompressionMode.Decompress)
reader = StreamReader.New(gzip)
data = reader.readToEnd()
reader.close();
reader.dispose();
gzip.dispose();
fileStream.dispose();

if data == "Test GZip ;)" then
print("#10 - GZip stream 'test-gzip.txt'                   V\n")
test_count = test_count + 1
else
print("#10 - GZip stream 'test-gzip.txt'                   X\n")
end

fileStream = File.create("test-folder/test-deflate.txt")
deflate = DeflateStream.New(fileStream, CompressionMode.Compress)
writer = StreamWriter.New(deflate)
writer.write("Test Deflate ;)")
writer.flush()
writer.close();
writer.dispose();
deflate.dispose();
fileStream.dispose();

fileStream = File.open("test-folder/test-deflate.txt", FileMode.Open)
deflate = DeflateStream.New(fileStream, CompressionMode.Decompress)
reader = StreamReader.New(deflate)
data = reader.readToEnd()
reader.close();
reader.dispose();
fileStream.dispose();
deflate.dispose();
fileStream.dispose();

if data == "Test Deflate ;)" then
print("#11 - Deflate stream 'test-deflate.txt'             V\n")
test_count = test_count + 1
else
print("#11 - Deflate stream 'test-deflate.txt'             X\n")
end

File.delete("test-folder/test-file.txt")

if File.exists("test-folder/test-file.txt") == true then
print("#12 - Delete file 'test-folder/test-file.txt'       X\n")
else
print("#12 - Delete file 'test-folder/test-file.txt'       V\n")
test_count = test_count + 1
end

File.delete("testzip.zip")
File.delete("test-folder/test-gzip.txt")
File.delete("test-folder/test-deflate.txt")
File.delete("test-folder2/test-file.txt")

Directory.delete("test-folder")

if Directory.exists("test-folder") == true then
print("#13 - Delete directory 'test-folder'                X\n")
else
print("#13 - Delete directory 'test-folder'                V\n")
test_count = test_count + 1
end

--Directory.delete("test-folder2")
print("-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n")
if test_count == 14 then
print("              All tests have passed!\n")
else
print("            Some of the 14 tests failed!\n")
end