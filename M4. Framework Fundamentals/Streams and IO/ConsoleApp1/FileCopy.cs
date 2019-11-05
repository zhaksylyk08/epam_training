using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FileCopy
    {
        private string sourcePath;
        private string destinationPath;

        public FileCopy(string sp, string dp)
        {
            this.sourcePath = sp;
            this.destinationPath = dp;
        }

        public long ByteCopyUsingFileStream()
        {
            long cnt = 0;

            using (var fs1 = new FileStream(sourcePath, FileMode.Open))
            {
                using (var fs2 = new FileStream(destinationPath, FileMode.OpenOrCreate)) 
                {
                    for (int i = 0; i < fs1.Length; i++)
                    {
                        byte b = (byte)fs1.ReadByte();
                        fs2.WriteByte(b);
                    }

                    cnt = fs2.Position;
                }
            }

            return cnt;
        }

        public long ByteCopyUsingMemoryStream()
        {
            long cnt = 0;

            using (var memStream = new MemoryStream())
            using (var sr = new StreamReader(sourcePath))
            {
                string fileText = sr.ReadToEnd();
                // write string to MemoryStream byte by byte
                for (int i = 0; i < fileText.Length; i++)
                    memStream.WriteByte((byte)fileText[i]);

                memStream.Position = 0;

                using (var fs = new FileStream(destinationPath, FileMode.OpenOrCreate)) 
                {
                    for (int i = 0; i < memStream.Length; i++)
                    {
                        byte el = (byte)memStream.ReadByte();
                        fs.WriteByte(el);
                    }

                    cnt = fs.Position;
                }
            }

                return cnt;
        }

        public int CopyUsingFileStreamBuffering()
        {
            int cnt = 0;

            using (var fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                int numBytesToRead = (int)fs.Length;
                int numBytesRead = 0;

                while (numBytesToRead > 0) 
                {
                    int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                numBytesToRead = bytes.Length;

                //Write bytes array to destination file
                using (var fsDestination = new FileStream(destinationPath, FileMode.OpenOrCreate,
                                                          FileAccess.Write))
                {
                    fsDestination.Write(bytes, 0, numBytesToRead);
                }

                cnt = numBytesToRead;
            }

            return cnt;
        }

        public long CopyUsingBufferedStream()
        {
            long cnt = 0;

            using (var fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (var bfs = new BufferedStream(fs, (int)fs.Length))
            {
                bfs.ReadByte();

                bfs.Position = 0;

                using (var fs2 = new FileStream(destinationPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    bfs.CopyTo(fs2);
                    cnt = fs2.Position;
                }
            }
            
            return cnt;
        }

    }
}
