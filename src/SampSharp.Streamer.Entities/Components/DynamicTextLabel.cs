// SampSharp.Streamer
// Copyright 2020 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace SampSharp.Streamer.Entities
{
    /// <summary>
    /// Represents a component which provides the data and functionality of an dynamic text label.
    /// </summary>
    public sealed class DynamicTextLabel : Component
    {
        #region Properties

        private string _text;
        private Color _color;

        #endregion

        #region Constructor

        private DynamicTextLabel(string text, Color color, Vector3 position, float drawDistance, int virtualWorld)
        {
            _text = text;
            _color = color;
            Position = position;
            DrawDistance = drawDistance;
            VirtualWorld = virtualWorld;
        }

        #endregion

        /// <summary>
        /// Gets whether this dynamic text label is valid.
        /// </summary>
        public bool IsValid => GetComponent<NativeDynamicTextLabel>().IsValidDynamic3DTextLabel();

        /// <summary>
        /// Gets or sets the text of this dynamic text label.
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                GetComponent<NativeDynamicTextLabel>().UpdateDynamic3DTextLabelText(Color, value ?? string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the color of this dynamic text label.
        /// </summary>
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                GetComponent<NativeDynamicTextLabel>().UpdateDynamic3DTextLabelText(value, Text);
            }
        }

        /// <summary>
        /// Gets the position of this dynamic text label.
        /// </summary>
        public Vector3 Position { get; }

        /// <summary>
        /// Gets the draw distance of this dynamic text label.
        /// </summary>
        public float DrawDistance { get; }

        /// <summary>
        /// Gets the virtual world of this dynamic text label.
        /// </summary>
        public int VirtualWorld { get; }

        /// <inheritdoc />
        protected override void OnDestroyComponent()
        {
            GetComponent<NativeDynamicTextLabel>().DestroyDynamic3DTextLabel();
        }
    }
}