using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using ToronPuzzle.Data;


[Serializable]
public class StringStringDictionary : SerializableDictionary<string, string> {}

[Serializable]
public class ObjectColorDictionary : SerializableDictionary<UnityEngine.Object, Color> {}

[Serializable]
public class FloatObjectDictionary : SerializableDictionary<float, GameObject> { }


[Serializable]
public class StringObjectDictionary : SerializableDictionary<string, GameObject> { }
[Serializable]
public class StringAudioDictionary : SerializableDictionary<string, AudioSource> { }


[Serializable]
public class ColorArrayStorage : SerializableDictionary.Storage<Color[]> {}

[Serializable]
public class ObjectArrayStorage : SerializableDictionary.Storage<GameObject[]> { }


[Serializable]
public class StringColorArrayDictionary : SerializableDictionary<string, Color[], ColorArrayStorage> {}

[Serializable]
public class SkinenumAddressDictionary : SerializableDictionary<PlacingCaseSkin, string> { }


[Serializable]
public class SequenceVector3Dictionary : SerializableDictionary<GameSequence, Vector3> { }

[Serializable]
public class SequenceTimeDictionary : SerializableDictionary<GameSequence,Vector2> { }
[Serializable]
public class StringSpriteDictionary : SerializableDictionary<string, Sprite> { }


[Serializable]
public class SituationEventDictionary : SerializableDictionary<CalledSituation, UnityEvent> { }
[Serializable]
public class ElementVectorDictionary : SerializableDictionary<BlockElement, Vector3> { }
[Serializable]
public class ElementIntDictionary : SerializableDictionary<BlockElement, int> { }


[Serializable]
public class StringVector2IntDictionary : SerializableDictionary<string, Vector2Int> { }


[Serializable]
public class StringObjectArrayDictionary : SerializableDictionary<string, GameObject[], ObjectArrayStorage> { }


[Serializable]
public class MyClass
{
    public int i;
    public string str;
}


public enum GameSequence
{
    VeryFirstStart,
    WaitForStart,
    ConveyerToInventory,
    InventoryToHoldingPanel,
    ConveyerToHoldingPanel,
    CalcDamage,
    BackToBegin,
    EndOfGame,
}
public enum CalledSituation
{
    ModuleToRate,
    SetOnSequence,
    BlockPlaced,
    AtTheEnd
}
public enum BlockElement
{
    Aggressive,
    Cynical,
    Friendly,
    Emptiness,
    Bonus
}


[Serializable]
public class QuaternionMyClassDictionary : SerializableDictionary<Quaternion, MyClass> {}