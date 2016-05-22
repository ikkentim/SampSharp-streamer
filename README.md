Streamer wrapper for SampSharp
=====================

A wrapper of the popular SA-MP streamer plugin for SampSharp.

**You need to load the streamer or all the events won't work**

``` c#
// Within your gamemode...
protected override void LoadControllers(ControllerCollection controllers)
{
    base.LoadControllers(controllers);

    // Load the streamer controllers
    Streamer.Load(this, controllers);
}
```
