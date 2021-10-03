using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringStringDictionary))]
[CustomPropertyDrawer(typeof(ObjectColorDictionary))]
[CustomPropertyDrawer(typeof(FloatObjectDictionary))]
[CustomPropertyDrawer(typeof(StringObjectDictionary))]
[CustomPropertyDrawer(typeof(StringObjectArrayDictionary))]
[CustomPropertyDrawer(typeof(SkinenumAddressDictionary))]

[CustomPropertyDrawer(typeof(StringAudioDictionary))]
[CustomPropertyDrawer(typeof(SequenceVector3Dictionary))]
[CustomPropertyDrawer(typeof(SequenceTimeDictionary))]
[CustomPropertyDrawer(typeof(StringSpriteDictionary))]

[CustomPropertyDrawer(typeof(ElementVectorDictionary))]
[CustomPropertyDrawer(typeof(ElementIntDictionary))]

[CustomPropertyDrawer(typeof(StringVector2IntDictionary))]

[CustomPropertyDrawer(typeof(StringColorArrayDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}

[CustomPropertyDrawer(typeof(ObjectArrayStorage))]
[CustomPropertyDrawer(typeof(ColorArrayStorage))]
public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}
