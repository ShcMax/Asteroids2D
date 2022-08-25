using UnityEngine;

namespace Builder.Scripts
{
    public class BuilderExample : MonoBehaviour
    {
        [SerializeField]
        private Sprite _view;


        [ContextMenu("Test Builder")]
        private void TestBuilder()
        {
            var gameObjectBuilder = new GameObjectBuilder();

            var buildResult = gameObjectBuilder
                .Rigidbody2D(1f)
                .Visual
                .Name("Builder")
                .Sprite(_view)
                .Physics
                .BoxCollider2D();

            Debug.Log("BuilderExample.TestBuilder: buildResult = " + buildResult);
        }

        [ContextMenu("Test Fluent Builder")]
        private void TestFluentBuilder()
        {
            var fluentGameObject = new GameObject()
                .SetName("Fluent")
                .AddBoxCollider2D()
                .AddRigidbody2D(1f)
                .AddSprite(_view);

            Debug.Log("BuilderExample.TestFluentBuilder: fluentGameObject = " + fluentGameObject);
        }

        [ContextMenu("Test Fluent Builder Chained")]
        private void TestFluentBuilderChained()
        {
            var fluentGameObjectChained = new GameObject()
                .GetOrAddComponentChained<SpriteRenderer>()
                .GetOrAddComponentChained<Rigidbody2D>()
                .GetOrAddComponentChained<BoxCollider2D>();

            Debug.Log("BuilderExample.TestFluentBuilderChained: fluentGameObjectChained = " + fluentGameObjectChained);
        }
    }
}