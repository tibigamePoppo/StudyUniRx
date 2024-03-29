using UnityEngine;

namespace Scenes.InGame.Ball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField, Tooltip("Ballのプレファブを入れる")]
        GameObject _ballPrefab;

        [Header("スポーンに関するパラメータ")]
        [SerializeField, Tooltip("スティックからy軸にオフセットする距離")]
        private float _yOffsetDistance = 0.5f;

        //TODO:現在InGameManagerからスポーンさせています。これをInGameManagerからイベントを発行させ、このスクリプト受け取って自分でSpawnさせるように変更しましょう
        public void Spawn()
        {
            var Stick = GameObject.FindWithTag("Player");
            Instantiate(_ballPrefab, Stick.transform.position + new Vector3(0, _yOffsetDistance, 0), Quaternion.identity, transform.parent);
        }
    }
}