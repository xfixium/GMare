#region MIT

// 
// GMare.
// Copyright (C) 2011 Michael Mercado
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

#endregion

using System;
using System.Runtime.Serialization;

namespace OcarinaRoomEditor
{
    /// <summary>
    /// Serialization binder, to convert Ocarina Room Editor project data.
    /// </summary>
    public class RoomBinder : SerializationBinder
    {
        /// <summary>
        /// Override bind to type method.
        /// </summary>
        /// <param name="assemblyName">The source assembly name.</param>
        /// <param name="typeName">Source type name.</param>
        /// <returns>The converted type.</returns>
        public override Type BindToType(string assemblyName, string typeName)
        {
            // Target strings, for things that need to be converted.
            string roomAssembly = "Ocarina Room Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            string room = "OcarinaRoomEditor.Room";
            string shapeAssembly = assemblyName = "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            string shape = "System.Collections.Generic.List`1[[OcarinaRoomEditor.Shape, Ocarina Room Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]";

            // Get the default type.
            Type type = Type.GetType(typeName);

            // Convert room type.
            if (assemblyName == roomAssembly && typeName == room)
                type = Type.GetType(room);

            // Convert shape list type.
            if (assemblyName == shapeAssembly && typeName == shape)
                type = Type.GetType(typeName = "System.Collections.Generic.List`1[[OcarinaRoomEditor.Shape, GMare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]");

            // Return target type.
            return type;
        }
    }
}
