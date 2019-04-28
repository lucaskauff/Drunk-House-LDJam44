using UnityEngine;
using UnityEngine.Video;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/GlitchEffect")]
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(VideoPlayer))]
public class VHSPostProcessEffect : MonoBehaviour
{
    public Shader shader;
    public VideoClip VHSClip;

    private float _yScanline;
    private float _xScanline;
    [SerializeField] [Range (0 ,1)] private int _IsBlacked;
    private Material _material = null;
	private VideoPlayer _player;

	void Start()
	{
		_material = new Material(shader);
		_player = GetComponent<VideoPlayer>();
		_player.isLooping = true;
		_player.renderMode = VideoRenderMode.APIOnly;
		_player.audioOutputMode = VideoAudioOutputMode.None;
		_player.clip = VHSClip;
		_player.Play();
	}

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		_material.SetTexture("_VHSTex", _player.texture);

		_yScanline += Time.deltaTime * 0.01f;
		_xScanline -= Time.deltaTime * 0.1f;

		if (_yScanline >= 1)
		{
			_yScanline = Random.value;
		}
		if (_xScanline <= 0 || Random.value < 0.05)
		{
			_xScanline = Random.value;
		}
		_material.SetFloat("_yScanline", _yScanline);
		_material.SetFloat("_xScanline", _xScanline);
        _material.SetFloat("_IsBlacked", _IsBlacked);
        Graphics.Blit(source, destination, _material);
	}

	protected void OnDisable()
	{
		if (_material)
		{
			DestroyImmediate(_material);
		}
	}
}
