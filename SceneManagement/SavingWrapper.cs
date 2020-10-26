using RPG.Saving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class SavingWrapper: MonoBehaviour
    {
        const string defaultSaveFile = "save";
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
        }

        private void Load()
        {
            GetComponent<SavingSystem>().Load();
        }
    }
}
