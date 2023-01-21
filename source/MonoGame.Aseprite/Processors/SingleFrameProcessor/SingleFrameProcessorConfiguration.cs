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

namespace MonoGame.Aseprite.Processors;
/// <summary>
///     Defines the configuration for the <see cref="SingleFrameProcessor"/>.
/// </summary>
public class SingleFrameProcessorConfiguration
{
    /// <summary>
    ///     Gets or Sets the index of the frame in the Aseprite file to process.
    /// </summary>
    public int FrameIndex { get; set; } = 0;

    /// <summary>
    ///     Gets or Sets a value that indicates whether only on cels on visible layers should be processed.
    /// </summary>
    public bool OnlyVisibleLayers { get; set; } = true;

    /// <summary>
    ///     Gets or Sets a value that indicates whether cels on the layer set as the background layer in Aseprite should
    ///     be processed.
    /// </summary>
    public bool IncludeBackgroundLayer { get; set; } = true;

    /// <summary>
    ///     Gets or Sets a value that indicates whether cels on a tilemap layer should be processed.
    /// </summary>
    public bool IncludeTilemapLayers { get; set; } = true;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SingleFrameProcessorConfiguration"/> class with the default
    ///     values.
    /// </summary>
    public SingleFrameProcessorConfiguration() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="SingleFrameProcessorConfiguration"/> class.
    /// </summary>
    /// <param name="frameIndex">
    ///     The index of the frame in the Aseprite file to process.
    /// </param>
    /// <param name="onlyVisibleLayers">
    ///     Indicates whether only on cels on visible layers should be processed.
    /// </param>
    /// <param name="includeBackgroundLayer">
    ///     Indicates whether cels on the layer set as the background layer in Aseprite should be processed.
    /// </param>
    /// <param name="includeTilemapLayers">
    ///     Indicates whether cels on a tilemap layer should be processed.
    /// </param>
    public SingleFrameProcessorConfiguration(int frameIndex, bool onlyVisibleLayers, bool includeBackgroundLayer, bool includeTilemapLayers) =>
        (FrameIndex, OnlyVisibleLayers, IncludeBackgroundLayer, IncludeTilemapLayers) = (frameIndex, onlyVisibleLayers, includeBackgroundLayer, includeTilemapLayers);
}
