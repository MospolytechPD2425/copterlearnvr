using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Details;

namespace Monitors
{
    public class Monitor : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _description;
        public void SetDetail(Detail detail)
        {
            _title.text = detail.Title;
            _image.sprite = detail.Sprite;
            _image.enabled = true;
            _description.text = $"    {detail.Description}";
        }
        public void SetTitle(string title)
        {
            _title.text = title;
        }
        public void Clear()
        {
            _title.text = "";
            _image.enabled = false;
            _description.text = "";
        }
    }
}
