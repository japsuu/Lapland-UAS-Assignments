using UnityEngine;

namespace DocFxForUnity
{
    /// <summary>
    /// Example player class.
    /// </summary>
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// Example private int speed variable.
        /// </summary>
        private int _speed;

        /// <summary>
        /// Example public static int variable for player count.
        /// </summary>
        public static int PlayerCount;
        
        /// <summary>
        /// Example public getter for speed.
        /// </summary>
        public int Speed => _speed;


        /// <summary>
        /// Example public method for moving the player.
        /// </summary>
        public void Move()
        {
            //TODO: Example method
        }


        /// <summary>
        /// Example public method for moving the player to a direction.
        /// </summary>
        /// <param name="direction">Direction to move to.</param>
        public void Move(Vector3 direction)
        {
            //TODO: Example method
        }


        /// <summary>
        ///  Checks if the player is grounded.
        /// </summary>
        /// <returns>true if player is grounded</returns>
        public bool IsGrounded()
        {
            return true;
        }
    }
}