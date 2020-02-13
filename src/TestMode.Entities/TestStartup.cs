﻿// SampSharp.Streamer
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

using Microsoft.Extensions.DependencyInjection;

using SampSharp.Core.Natives.NativeObjects;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using SampSharp.Streamer.Entities;

namespace TestMode.Entities
{
    public class TestStartup : IStartup
    {
        public void Configure(IServiceCollection services)
        {
            services
                .AddTransient<IStreamerService, StreamerService>()
                .AddSystemsInAssembly();
        }

        public void Configure(IEcsBuilder builder)
        {
            builder
                .EnableSampEvents()
                .EnablePlayerCommands()
                .EnableStreamerEvents();

            WarmUpNativeObjects();
        }

        private void WarmUpNativeObjects()
        {
            // Warm up native objects for profiling purposes

            // Components
            NativeObjectProxyFactory.CreateInstance<NativeDynamicObject>();
            NativeObjectProxyFactory.CreateInstance<NativeStreamerPlayer>();

            // Services
            NativeObjectProxyFactory.CreateInstance<StreamerServiceNative>();
        }
    }
}