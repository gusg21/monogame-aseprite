/* ----------------------------------------------------------------------------
MIT License

Copyright (c) 2018-2023 Christopher Whitley

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
---------------------------------------------------------------------------- */

using MonoGame.Aseprite.RawTypes;

namespace MonoGame.Aseprite.Content.Readers;

/// <summary>
///     Defines a reader that reads a <see cref="RawSpriteSheet"/> from a file.
/// </summary>
public static class RawSpriteSheetReader
{
    /// <summary>
    ///     Reads the <see cref="RawSpriteSheet"/> from the file at the specified path.
    /// </summary>
    /// <param name="path">
    ///     The path and name of the file that contains the <see cref="RawSpriteSheet"/> to read.
    /// </param>
    /// <returns>
    ///     The <see cref="RawSpriteSheet"/> that was read.
    /// </returns>
    public static RawSpriteSheet Read(string path)
    {
        using Stream stream = File.OpenRead(path);
        using BinaryReader reader = new(stream);
        return Read(reader);
    }

    internal static RawSpriteSheet Read(BinaryReader reader)
    {
        reader.ReadMagic();
        string name = reader.ReadString();
        RawTextureAtlas atlas = reader.ReadRawTextureAtlas();
        int tagCount = reader.ReadInt32();

        RawAnimationTag[] tags = new RawAnimationTag[tagCount];

        for (int i = 0; i < tagCount; i++)
        {
            string tagName = reader.ReadString();
            int loopCount = reader.ReadInt32();
            bool isReversed = reader.ReadBoolean();
            bool isPingPong = reader.ReadBoolean();
            int frameCount = reader.ReadInt32();

            RawAnimationFrame[] frames = new RawAnimationFrame[frameCount];

            for (int j = 0; j < frameCount; j++)
            {
                int index = reader.ReadInt32();
                int duration = reader.ReadInt32();
                frames[j] = new(index, duration);
            }

            tags[i] = new(tagName, frames, loopCount, isReversed, isPingPong);
        }

        return new(name, atlas, tags);
    }
}
