using System.Runtime.InteropServices;

CrewMember? member = new("Beverly Crusher");
WeakReference<CrewMember> weak = new(member);

if (weak.TryGetTarget(out CrewMember? target))
{
  Console.WriteLine($"Weak target is currently available: {target.Name}");
}

member = null;
Console.WriteLine("Removed the strong local reference. The weak reference does not keep the target alive.");

PreviewCache cache = new();
byte[] preview = cache.GetPreview("profile-42");
Console.WriteLine($"Preview length: {preview.Length}");
cache.RemoveCollectedEntries();

byte[] buffer = new byte[1024];
GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
try
{
  IntPtr address = handle.AddrOfPinnedObject();
  Console.WriteLine($"Pinned buffer address: 0x{address.ToString("x")}");
}
finally
{
  handle.Free();
}

Console.WriteLine("GCHandle is for advanced interop and pinning scenarios. Always free handles you allocate.");

public sealed record CrewMember(string Name);

public sealed class PreviewCache
{
  private readonly Dictionary<string, WeakReference<byte[]>> _previews = new();

  public byte[] GetPreview(string key)
  {
    if (_previews.TryGetValue(key, out WeakReference<byte[]>? weak)
        && weak.TryGetTarget(out byte[]? cached))
    {
      return cached;
    }

    byte[] generated = new byte[4096];
    Random.Shared.NextBytes(generated);
    _previews[key] = new WeakReference<byte[]>(generated);
    return generated;
  }

  public void RemoveCollectedEntries()
  {
    foreach (string key in _previews.Keys.ToList())
    {
      if (!_previews[key].TryGetTarget(out _))
      {
        _previews.Remove(key);
      }
    }
  }
}
