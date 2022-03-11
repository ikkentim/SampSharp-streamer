// SampSharp.Streamer
// Copyright 2018 Tim Potze
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

using System;
using System.Linq;
using SampSharp.GameMode;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.Definitions;
using SampSharp.Streamer.Events;

namespace SampSharp.Streamer.World
{
    public partial class DynamicActor : DynamicWorldObject<DynamicActor>
    {
        public DynamicActor(int modelid, Vector3 position, float angle, bool invulnerable = true, float health = 100.0f, float streamdistance = 200,
            int worldid = -1, int interiorid = -1, BasePlayer player = null, DynamicArea area = null, int priority = 0)
        {
            Id = Internal.CreateDynamicActor(modelid, position.X, position.Y, position.Z, angle, invulnerable, health, worldid, interiorid,
                player?.Id ?? -1, streamdistance, area?.Id ?? -1, priority);
        }

        public DynamicActor(int modelid, float angle, Vector3 position, bool invulnerable = true, float health = 100.0f, float streamdistance = 200,
            int[] worlds = null, int[] interiors = null, BasePlayer[] players = null, DynamicArea[] areas = null, int priority = 0)
        {
            worlds ??= new[] { -1 };
            interiors ??= new[] { -1 };
            var pl = players?.Select(p => p.Id).ToArray() ?? new[] { -1 };
            var ar = areas?.Select(a => a.Id).ToArray() ?? new[] { -1 };

            Id = Internal.CreateDynamicActorEx(modelid, position.X, position.Y, position.Z, angle, invulnerable, health,
                streamdistance, worlds, interiors, pl, ar, priority, worlds.Length, interiors.Length, pl.Length, ar.Length);
        }

        #region Overrides of DynamicWorldObject<DynamicActor>

        public override StreamType StreamType
        {
            get
            {
                AssertNotDisposed();
                return StreamType.Actor;
            }
        }

        #endregion

        public bool IsValid
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsValidDynamicActor(Id);
            }
        }

        public virtual float FacingAngle
        {
            get
            {
                AssertNotDisposed();

                Internal.GetDynamicActorFacingAngle(Id, out var angle);
                return angle;
            }
            set
            {
                AssertNotDisposed();
                Internal.SetDynamicActorFacingAngle(Id, value);
            }
        }

        public virtual float Health
        {
            get
            {
                AssertNotDisposed();

                Internal.GetDynamicActorHealth(Id, out var angle);
                return angle;
            }
            set
            {
                AssertNotDisposed();
                Internal.SetDynamicActorHealth(Id, value);
            }
        }

        public virtual bool IsInvulnerable
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsDynamicActorInvulnerable(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetDynamicActorInvulnerable(Id, value);
            }
        }

        public bool IsStreamedIn(BasePlayer forPlayer)
        {
            AssertNotDisposed();

            if (forPlayer == null) throw new ArgumentNullException(nameof(forPlayer));
            return Internal.IsDynamicActorStreamedIn(Id, forPlayer.Id);
        }

        public void CleanAnimations()
        {
            AssertNotDisposed();

            Internal.ClearDynamicActorAnimations(Id);
        }

        public void ApplyAnimation(string animLib, string animName, float delta, bool loop, bool lockX, bool lockY, bool freeze, int time)
        {
            AssertNotDisposed();

            if (animLib == null) throw new ArgumentNullException(nameof(animLib));
            if (animName == null) throw new ArgumentNullException(nameof(animName));

            Internal.ApplyDynamicActorAnimation(Id, animLib, animName, delta, loop, lockX, lockY, freeze, time);
        }

        public void GetAnimation(out string animLib, out string animName, out float delta, out bool loop, out bool lockX, out bool lockY,
            out bool freeze, out int time)
        {
            AssertNotDisposed();

            Internal.GetDynamicActorAnimation(Id, out animLib, out animName, out delta, out loop, out lockX, out lockY, out freeze, out time, 64, 64);
        }

        #region Overrides of IdentifiedPool<DynamicActor>

        /// <summary>
        ///     Removes this instance from the pool.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            Internal.DestroyDynamicActor(Id);

            base.Dispose(disposing);
        }

        #endregion

        #region Overrides of DynamicWorldObject<DynamicActor>

        public override int World
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetDynamicActorVirtualWorld(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetDynamicActorVirtualWorld(Id, value);
            }
        }

        public override Vector3 Position
        {
            get
            {
                AssertNotDisposed();

                Internal.GetDynamicActorPos(Id, out var x, out var y, out var z);
                return new Vector3(x, y, z);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetDynamicActorPos(Id, value.X, value.Y, value.Z);
            }
        }

        #endregion

        public event EventHandler<PlayerEventArgs> StreamIn; 

        public event EventHandler<PlayerEventArgs> StreamOut; 

        public event EventHandler<PlayerShotActorEventArgs> PlayerGiveDamage; 

        public virtual void OnStreamIn(PlayerEventArgs args)
        {
            AssertNotDisposed();

            StreamIn?.Invoke(this, args);
        }

        public virtual void OnStreamOut(PlayerEventArgs args)
        {
            AssertNotDisposed();

            StreamOut?.Invoke(this, args);
        }

        public virtual void OnPlayerGiveDamage(PlayerShotActorEventArgs args)
        {
            AssertNotDisposed();

            PlayerGiveDamage?.Invoke(this, args);
        }
    }
}