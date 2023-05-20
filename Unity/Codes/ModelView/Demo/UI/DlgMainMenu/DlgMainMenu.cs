namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgMainMenu :Entity,IAwake,IUILogic
	{

		public DlgMainMenuViewComponent View { get => this.Parent.GetComponent<DlgMainMenuViewComponent>();} 

		 

	}
}
