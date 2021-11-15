using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[CustomPropertyDrawer(typeof(StringStringDictionary))]
[CustomPropertyDrawer(typeof(ObjectColorDictionary))]
[CustomPropertyDrawer(typeof(FloatObjectDictionary))]
[CustomPropertyDrawer(typeof(StringObjectDictionary))]
[CustomPropertyDrawer(typeof(StringObjectArrayDictionary))]
[CustomPropertyDrawer(typeof(SkinenumAddressDictionary))]
[CustomPropertyDrawer(typeof(FXObjectDictionary))]

[CustomPropertyDrawer(typeof(KeyAimDictionary))]
[CustomPropertyDrawer(typeof(AudioSFXEnumDictionary))]
[CustomPropertyDrawer(typeof(SFXEnumFloatDictionary))]
[CustomPropertyDrawer(typeof(BackgroundObjectDictionary))]
[CustomPropertyDrawer(typeof(BGMAudioDictionary))]
[CustomPropertyDrawer(typeof(SFXAudioDictionary))]
[CustomPropertyDrawer(typeof(StatusObjectDictionary))]


[CustomPropertyDrawer(typeof(StringBlockInfoDictionary))]
[CustomPropertyDrawer(typeof(VectorCellDictionary))]

[CustomPropertyDrawer(typeof(StringAudioDictionary))]
[CustomPropertyDrawer(typeof(SequenceVector3Dictionary))]
[CustomPropertyDrawer(typeof(SequenceTimeDictionary))]
[CustomPropertyDrawer(typeof(StringSpriteDictionary))]

[CustomPropertyDrawer(typeof(ElementVectorDictionary))]
[CustomPropertyDrawer(typeof(ElementIntDictionary))]
[CustomPropertyDrawer(typeof(StringSpineAnimDictionary))]
[CustomPropertyDrawer(typeof(StringVector2IntDictionary))]

[CustomPropertyDrawer(typeof(StringColorArrayDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}

[CustomPropertyDrawer(typeof(ObjectArrayStorage))]
[CustomPropertyDrawer(typeof(ColorArrayStorage))]
public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}
