require("lua.security")

local function isempty(s)
  return s == nil or s == ''
end

test_count = 0

md5String = StringHash.hashStringToString("MD5", "Hello World!")
sha1String = StringHash.hashStringToString("SHA-1", "Hello World!")
sha256String = StringHash.hashStringToString("SHA-256", "Hello World!")
sha384String = StringHash.hashStringToString("SHA-384", "Hello World!")
sha512String = StringHash.hashStringToString("SHA-512", "Hello World!")

print("String MD5     -> " .. md5String .. "\n")
print("String SHA-1   -> " .. sha1String .. "\n")
print("String SHA-256 -> " .. sha256String .. "\n")
print("String SHA-384 -> " .. sha384String .. "\n")
print("String SHA-512 -> " .. sha512String .. "\n")

print("-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n")

if md5String == "ed076287532e86365e841e92bfc50d8c" then
print("# 1 - MD5 string hash 'Hello World!'                V\n")
test_count = test_count + 1
else
print("# 1 - MD5 string hash 'Hello World!'                X\n")
end

if sha1String == "2ef7bde608ce5404e97d5f042f95f89f1c232871" then
print("# 2 - SHA-1 string hash 'Hello World!'              V\n")
test_count = test_count + 1
else
print("# 2 - SHA-1 string hash 'Hello World!'              X\n")
end

if sha256String == "7f83b1657ff1fc53b92dc18148a1d65dfc2d4b1fa3d677284addd200126d9069" then
print("# 3 - SHA-256 string hash 'Hello World!'            V\n")
test_count = test_count + 1
else
print("# 3 - SHA-256 string hash 'Hello World!'            X\n")
end

if sha384String == "bfd76c0ebbd006fee583410547c1887b0292be76d582d96c242d2a792723e3fd6fd061f9d5cfd13b8f961358e6adba4a" then
print("# 4 - SHA-384 string hash 'Hello World!'            V\n")
test_count = test_count + 1
else
print("# 4 - SHA-384 string hash 'Hello World!'            X\n")
end

if sha512String == "861844d6704e8573fec34d967e20bcfef3d424cf48be04e6dc08f2bd58c729743371015ead891cc3cf1c9d34b49264b510751b1ff9e537937bc46b5d6ff4ecc8" then
print("# 5 - SHA-512 string hash 'Hello World!'            V\n")
test_count = test_count + 1
else
print("# 5 - SHA-512 string hash 'Hello World!'            X\n")
end

print("-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n \n")

require("lua.io")

fileStream = File.create("hash-file.txt")
writer = StreamWriter.New(fileStream)
writer.write("Hello World!")
writer.flush()
writer.close();
writer.dispose();
fileStream.dispose();

fileStream = File.open("hash-file.txt", FileMode.Open)

md5String = FileHash.hashStreamToString("MD5", fileStream)
sha1String = FileHash.hashStreamToString("SHA-1", fileStream)
sha256String = FileHash.hashStreamToString("SHA-256", fileStream)
sha384String = FileHash.hashStreamToString("SHA-384", fileStream)
sha512String = FileHash.hashStreamToString("SHA-512", fileStream)

print("File MD5     -> " .. md5String .. "\n")
print("File SHA-1   -> " .. sha1String .. "\n")
print("File SHA-256 -> " .. sha256String .. "\n")
print("File SHA-384 -> " .. sha384String .. "\n")
print("File SHA-512 -> " .. sha512String .. "\n")

print(" \n-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n")

if md5String == "ed076287532e86365e841e92bfc50d8c" then
print("# 6 - MD5 file hash 'Hello World!'                  V\n")
test_count = test_count + 1
else
print("# 6 - MD5 file hash 'Hello World!'                  X\n")
end

if sha1String == "da39a3ee5e6b4b0d3255bfef95601890afd80709" then
print("# 7 - SHA-1 file hash 'Hello World!'                V\n")
test_count = test_count + 1
else
print("# 7 - SHA-1 file hash 'Hello World!'                X\n")
end

if sha256String == "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855" then
print("# 8 - SHA-256 file hash 'Hello World!'              V\n")
test_count = test_count + 1
else
print("# 8 - SHA-256 file hash 'Hello World!'              X\n")
end

if sha384String == "38b060a751ac96384cd9327eb1b1e36a21fdb71114be07434c0cc7bf63f6e1da274edebfe76f65fbd51ad2f14898b95b" then
print("# 9 - SHA-384 file hash 'Hello World!'              V\n")
test_count = test_count + 1
else
print("# 9 - SHA-384 file hash 'Hello World!'              X\n")
end

if sha512String == "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e" then
print("#10 - SHA-512 file hash 'Hello World!'              V\n")
test_count = test_count + 1
else
print("#10 - SHA-512 file hash 'Hello World!'              X\n")
end

print("-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n")
if test_count == 10 then
print("              All tests have passed!\n")
else
print("            Some of the 10 tests failed!\n")
end