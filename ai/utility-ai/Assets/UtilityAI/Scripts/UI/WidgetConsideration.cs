using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AI.Utility
{
    public class WidgetConsideration : MonoBehaviour
    {
        public TMP_Text txtName;
        public TMP_Text txtScore;

        private ActionObj action;
        private int conIdx;

        public void Show(ActionObj act, int conIdx)
        {
            gameObject.SetActive(true);

            this.action = act;
            this.conIdx = conIdx;

            var con = act.considerations[conIdx];
            txtName.text = con.name;
            txtScore.text = act.GetConsiderationScore(conIdx).ToString("F2");
        }

        public void Hide()
        {
            action = null;
            gameObject.SetActive(false);
        }

        public void Refresh()
        {
            if (gameObject.activeSelf == false || action == null)
                return;

            txtScore.text = action.GetConsiderationScore(conIdx).ToString("F2");
        }
    }
}
