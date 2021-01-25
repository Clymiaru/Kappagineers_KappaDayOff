using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollBarBasedOrientation : MonoBehaviour
{
	private ContentSizeFitter contentSizeFitter;

	private DeviceOrientation currentOrientation = DeviceOrientation.LandscapeLeft;
	private GridLayoutGroup   gridLayout;
	private ScrollRect        scrollView;

	private void Awake()
	{
		scrollView        = GetComponent<ScrollRect>();
		contentSizeFitter = scrollView.content.GetComponent<ContentSizeFitter>();
		gridLayout        = scrollView.content.GetComponent<GridLayoutGroup>();
	}

	private void Update()
	{
		if (currentOrientation == Input.deviceOrientation)
		{
			return;
		}

		currentOrientation = Input.deviceOrientation;
		UpdateScrollViewOnOrientation();
	}

	private void UpdateScrollViewOnOrientation()
	{
		if (currentOrientation == DeviceOrientation.Portrait ||
		    currentOrientation == DeviceOrientation.PortraitUpsideDown)
		{
			scrollView.horizontal = false;
			scrollView.vertical   = true;

			contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
			contentSizeFitter.verticalFit   = ContentSizeFitter.FitMode.PreferredSize;

			gridLayout.constraint      = GridLayoutGroup.Constraint.FixedColumnCount;
			gridLayout.constraintCount = 1;
		}
		else if (currentOrientation == DeviceOrientation.LandscapeLeft ||
		         currentOrientation == DeviceOrientation.LandscapeRight)
		{
			scrollView.horizontal = true;
			scrollView.vertical   = false;

			contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
			contentSizeFitter.verticalFit   = ContentSizeFitter.FitMode.MinSize;

			gridLayout.constraint      = GridLayoutGroup.Constraint.FixedRowCount;
			gridLayout.constraintCount = 1;
		}
	}
}