// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

namespace SixLabors.ImageSharp.Tests
{
    using System.IO;

    using Xunit;

    using ImageSharp.Formats;
    using ImageSharp.Formats.Tiff;

    public class TiffEncoderHeaderTests
    {
        [Fact]
        public void WriteHeader_WritesValidHeader()
        {
            MemoryStream stream = new MemoryStream();
            TiffEncoderCore encoder = new TiffEncoderCore(null);

            using (TiffWriter writer = new TiffWriter(stream))
            {
                long firstIfdMarker = encoder.WriteHeader(writer);
            }

            Assert.Equal(new byte[] { 0x49, 0x49, 42, 0, 0x00, 0x00, 0x00, 0x00 }, stream.ToArray());
        }

        [Fact]
        public void WriteHeader_ReturnsFirstIfdMarker()
        {
            MemoryStream stream = new MemoryStream();
            TiffEncoderCore encoder = new TiffEncoderCore(null);

            using (TiffWriter writer = new TiffWriter(stream))
            {
                long firstIfdMarker = encoder.WriteHeader(writer);
                Assert.Equal(4, firstIfdMarker);
            }
        }
    }
}