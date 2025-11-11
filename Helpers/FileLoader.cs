using Godot;

namespace Frogger.Helpers;
public static class FileLoader
{
    /// <summary>
    /// Load file using ResourceLoader.Load<T>(path), throws FileNotFoundException if the file doesnt exist at path
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="System.IO.FileNotFoundException">throws FileNotFoundException if the file doesnt exist at path</exception>
    public static T LoadSafe<T>(string path) where T : class
    {
        var file = ResourceLoader.Load<T>(path);
        if (file == null)
        {
            throw new System.IO.FileNotFoundException($"File not found at {path}");
        }
        return file;
    }
}
