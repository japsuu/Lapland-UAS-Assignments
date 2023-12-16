using UnityEngine;

namespace DocFxForUnity
{
    /// <summary>
    /// Cube color enum.
    /// </summary>
    public enum CubeColor
    {
        /// <summary>
        /// Red color.
        /// </summary>
        RED,
        /// <summary>
        /// Green color.
        /// </summary>
        GREEN,
        /// <summary>
        /// Blue color.
        /// </summary>
        BLUE
    }
    
    
    /// <summary>
    /// Basic example cube class. Can move, rotate, and scale.
    /// Creates a cube primitive to scene.
    /// </summary>
    public class Cube : MonoBehaviour
    {
        /// <summary>
        /// Rotates the cube.
        /// </summary>
        /// <param name="rot">The new rotation of the cube</param>
        public void Rotate(Quaternion rot)
        {
            
        }
        
        
        /// <summary>
        /// Moves the cube.
        /// </summary>
        /// <param name="pos">Position to move to</param>
        public void Move(Vector3 pos)
        {
            
        }
        
        
        /// <summary>
        /// Scales the cube.
        /// </summary>
        /// <param name="scale">Scale to scale to</param>
        public void Scale(Vector3 scale)
        {
            
        }
        
        
        /// <summary>
        /// Changes the color of the cube.
        /// </summary>
        /// <param name="color">Color to change to</param>
        public void ChangeCubeColor(CubeColor color = CubeColor.RED)
        {
            
        }
    }
}