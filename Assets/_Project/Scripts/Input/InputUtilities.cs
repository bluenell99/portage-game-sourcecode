    using UnityEngine;

    public static class InputUtilities
    {
        /// <summary>
        /// Updates cursor lock state and visibility
        /// </summary>
        /// <param name="state"></param>
        public static void SetCursorLockState(bool state)
        {
            Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !state;
        }
    }
