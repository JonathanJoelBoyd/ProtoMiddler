/*This file is part of ProtoMiddler

ProtoMiddler is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

Foobar is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
 
Author: Jon Boyd
Email: jboyd[at]securityinnovation[dot]com

 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ProtoMiddler
{
    public static class ProtoBufUtil
    {

        public static string DecodeRaw(byte[] protobuf)
        {
            string retval = string.Empty;

            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo();
            procStartInfo.WorkingDirectory = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9";
            procStartInfo.FileName = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9\protoc.exe";
            procStartInfo.Arguments = @"--decode_raw";
            procStartInfo.RedirectStandardInput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(procStartInfo);

            // proc.StandardInput.BaseStream.Write(protobufBytes, 0, protobufBytes.Length);
            BinaryWriter binaryWriter = new BinaryWriter(proc.StandardInput.BaseStream);
            binaryWriter.Write(protobuf);
            binaryWriter.Flush();
            binaryWriter.Close();
            retval = proc.StandardOutput.ReadToEnd();

            return retval;
        }

        private static string GetFilePath(string fileName)
        {

            FileInfo fileInfo = new FileInfo(fileName);
            string f = fileInfo.Name;
            string filePath = fileInfo.FullName.Replace(f, string.Empty);

         //   MessageBox.Show(filePath);

            return filePath;

        }

        public static string DecodeWithProto(byte[] protobuf, string messageType, string protoFile)
        {
            string retval = string.Empty;

            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo();
            procStartInfo.WorkingDirectory = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9";
            procStartInfo.FileName = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9\protoc.exe";
            procStartInfo.Arguments = string.Format(@"--decode={0} --proto_path={1} {2}", messageType, GetFilePath(protoFile), protoFile);
            procStartInfo.RedirectStandardInput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(procStartInfo);

            // proc.StandardInput.BaseStream.Write(protobufBytes, 0, protobufBytes.Length);
            BinaryWriter binaryWriter = new BinaryWriter(proc.StandardInput.BaseStream);
            binaryWriter.Write(protobuf);
            binaryWriter.Flush();
            binaryWriter.Close();
            retval = proc.StandardOutput.ReadToEnd();

            return retval;
        }

        public static string Decode(byte [] protobuf)
        {
            string retval = string.Empty;

            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo();
            procStartInfo.WorkingDirectory = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9";
            procStartInfo.FileName = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9\protoc.exe";
            procStartInfo.Arguments = @"--decode=Account --proto_path=c:\me\ProtoBufTest c:\me\ProtoBufTest\Account.proto";
            procStartInfo.RedirectStandardInput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(procStartInfo);

            // proc.StandardInput.BaseStream.Write(protobufBytes, 0, protobufBytes.Length);
            BinaryWriter binaryWriter = new BinaryWriter(proc.StandardInput.BaseStream);
            binaryWriter.Write(protobuf);
            binaryWriter.Flush();
            binaryWriter.Close();
            retval = proc.StandardOutput.ReadToEnd();

            return retval;
        }

        public static byte[] EncodeWithProto(string strProtobuf, string messageType, string protoFile)
        {
            byte[] retval = null;

            // protoc.exe --encode=Account --proto_path=C:\me\ProtoBufTest C:\me\ProtoBufTest\Account.proto

            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo();
            procStartInfo.WorkingDirectory = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9";
            procStartInfo.FileName = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9\protoc.exe";
            procStartInfo.Arguments = string.Format(@"--encode={0} --proto_path={1} {2}", messageType, GetFilePath(protoFile), protoFile);
            procStartInfo.RedirectStandardInput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;

            //
            // write the decoded protobuf string to protoc for it to comiple into protobuf binary format.
            //
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(procStartInfo);
            StreamWriter streamWriter = new StreamWriter(proc.StandardInput.BaseStream);
            streamWriter.Write(strProtobuf);
            streamWriter.Flush();
            streamWriter.Close();

            // Now, read off it's standard output for the binary stream.

            BinaryReader binaryReader = new BinaryReader(proc.StandardOutput.BaseStream);
            byte[] buf = new byte[4096];
            int protoBufBytesRead = binaryReader.Read(buf, 0, 4096);

            if (protoBufBytesRead > 0)
            {
                retval = new byte[protoBufBytesRead];
                Array.Copy(buf, retval, protoBufBytesRead);
            }
            //binaryReader.Read(

            return retval;
        }

        public static byte[] Encode(string strProtobuf)
        {
            byte[] retval = null;

            // protoc.exe --encode=Account --proto_path=C:\me\ProtoBufTest C:\me\ProtoBufTest\Account.proto

            ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo();
            procStartInfo.WorkingDirectory = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9";
            procStartInfo.FileName = @"C:\Program Files (x86)\protobuf-net\protobuf-net-VS9\protoc.exe";
            procStartInfo.Arguments = @"--encode=Account --proto_path=c:\me\ProtoBufTest c:\me\ProtoBufTest\Account.proto";
            procStartInfo.RedirectStandardInput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;

            //
            // write the decoded protobuf string to protoc for it to comiple into protobuf binary format.
            //
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(procStartInfo);
            StreamWriter streamWriter = new StreamWriter(proc.StandardInput.BaseStream);
            streamWriter.Write(strProtobuf);
            streamWriter.Flush();
            streamWriter.Close();

            // Now, read off it's standard output for the binary stream.

            BinaryReader binaryReader = new BinaryReader(proc.StandardOutput.BaseStream);
            byte[] buf = new byte[4096];
            int protoBufBytesRead = binaryReader.Read(buf, 0, 4096);

            if (protoBufBytesRead > 0)
            {
                retval = new byte[protoBufBytesRead];
                Array.Copy(buf, retval, protoBufBytesRead);
            }
            //binaryReader.Read(

            return retval;
        }
    }
}
