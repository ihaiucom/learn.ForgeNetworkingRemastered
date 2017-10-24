using BeardedManStudios.Forge.Networking.Frame;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using UnityEngine;

namespace BeardedManStudios.Forge.Networking.Generated
{
	[GeneratedInterpol("{\"inter\":[0,0]")]
	public partial class ZfFirstTestNetworkObject : NetworkObject
	{
		public const int IDENTITY = 10;

		private byte[] _dirtyFields = new byte[1];

		#pragma warning disable 0067
		public event FieldChangedEvent fieldAltered;
		#pragma warning restore 0067
		private int _index;
		public event FieldEvent<int> indexChanged;
		public InterpolateUnknown indexInterpolation = new InterpolateUnknown() { LerpT = 0f, Enabled = false };
		public int index
		{
			get { return _index; }
			set
			{
				// Don't do anything if the value is the same
				if (_index == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x1;
				_index = value;
				hasDirtyFields = true;
			}
		}

		public void SetindexDirty()
		{
			_dirtyFields[0] |= 0x1;
			hasDirtyFields = true;
		}

		private void RunChange_index(ulong timestep)
		{
			if (indexChanged != null) indexChanged(_index, timestep);
			if (fieldAltered != null) fieldAltered("index", _index, timestep);
		}
		private int _value;
		public event FieldEvent<int> valueChanged;
		public InterpolateUnknown valueInterpolation = new InterpolateUnknown() { LerpT = 0f, Enabled = false };
		public int value
		{
			get { return _value; }
			set
			{
				// Don't do anything if the value is the same
				if (_value == value)
					return;

				// Mark the field as dirty for the network to transmit
				_dirtyFields[0] |= 0x2;
				_value = value;
				hasDirtyFields = true;
			}
		}

		public void SetvalueDirty()
		{
			_dirtyFields[0] |= 0x2;
			hasDirtyFields = true;
		}

		private void RunChange_value(ulong timestep)
		{
			if (valueChanged != null) valueChanged(_value, timestep);
			if (fieldAltered != null) fieldAltered("value", _value, timestep);
		}

		protected override void OwnershipChanged()
		{
			base.OwnershipChanged();
			SnapInterpolations();
		}
		
		public void SnapInterpolations()
		{
			indexInterpolation.current = indexInterpolation.target;
			valueInterpolation.current = valueInterpolation.target;
		}

		public override int UniqueIdentity { get { return IDENTITY; } }

		protected override BMSByte WritePayload(BMSByte data)
		{
			UnityObjectMapper.Instance.MapBytes(data, _index);
			UnityObjectMapper.Instance.MapBytes(data, _value);

			return data;
		}

		protected override void ReadPayload(BMSByte payload, ulong timestep)
		{
			_index = UnityObjectMapper.Instance.Map<int>(payload);
			indexInterpolation.current = _index;
			indexInterpolation.target = _index;
			RunChange_index(timestep);
			_value = UnityObjectMapper.Instance.Map<int>(payload);
			valueInterpolation.current = _value;
			valueInterpolation.target = _value;
			RunChange_value(timestep);
		}

		protected override BMSByte SerializeDirtyFields()
		{
			dirtyFieldsData.Clear();
			dirtyFieldsData.Append(_dirtyFields);

			if ((0x1 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _index);
			if ((0x2 & _dirtyFields[0]) != 0)
				UnityObjectMapper.Instance.MapBytes(dirtyFieldsData, _value);

			return dirtyFieldsData;
		}

		protected override void ReadDirtyFields(BMSByte data, ulong timestep)
		{
			if (readDirtyFlags == null)
				Initialize();

			Buffer.BlockCopy(data.byteArr, data.StartIndex(), readDirtyFlags, 0, readDirtyFlags.Length);
			data.MoveStartIndex(readDirtyFlags.Length);

			if ((0x1 & readDirtyFlags[0]) != 0)
			{
				if (indexInterpolation.Enabled)
				{
					indexInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					indexInterpolation.Timestep = timestep;
				}
				else
				{
					_index = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_index(timestep);
				}
			}
			if ((0x2 & readDirtyFlags[0]) != 0)
			{
				if (valueInterpolation.Enabled)
				{
					valueInterpolation.target = UnityObjectMapper.Instance.Map<int>(data);
					valueInterpolation.Timestep = timestep;
				}
				else
				{
					_value = UnityObjectMapper.Instance.Map<int>(data);
					RunChange_value(timestep);
				}
			}
		}

		public override void InterpolateUpdate()
		{
			if (IsOwner)
				return;

			if (indexInterpolation.Enabled && !indexInterpolation.current.Near(indexInterpolation.target, 0.0015f))
			{
				_index = (int)indexInterpolation.Interpolate();
				RunChange_index(indexInterpolation.Timestep);
			}
			if (valueInterpolation.Enabled && !valueInterpolation.current.Near(valueInterpolation.target, 0.0015f))
			{
				_value = (int)valueInterpolation.Interpolate();
				RunChange_value(valueInterpolation.Timestep);
			}
		}

		private void Initialize()
		{
			if (readDirtyFlags == null)
				readDirtyFlags = new byte[1];

		}

		public ZfFirstTestNetworkObject() : base() { Initialize(); }
		public ZfFirstTestNetworkObject(NetWorker networker, INetworkBehavior networkBehavior = null, int createCode = 0, byte[] metadata = null) : base(networker, networkBehavior, createCode, metadata) { Initialize(); }
		public ZfFirstTestNetworkObject(NetWorker networker, uint serverId, FrameStream frame) : base(networker, serverId, frame) { Initialize(); }

		// DO NOT TOUCH, THIS GETS GENERATED PLEASE EXTEND THIS CLASS IF YOU WISH TO HAVE CUSTOM CODE ADDITIONS
	}
}