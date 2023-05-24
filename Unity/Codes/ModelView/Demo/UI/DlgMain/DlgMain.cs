namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMain :Entity,IAwake,IUILogic
	{

		public DlgMainViewComponent View { get => this.Parent.GetComponent<DlgMainViewComponent>();} 

		 

	}
}
