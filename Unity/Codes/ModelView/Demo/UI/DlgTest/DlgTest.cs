namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTest :Entity,IAwake,IUILogic
	{

		public DlgTestViewComponent View { get => this.Parent.GetComponent<DlgTestViewComponent>();} 

		 

	}
}
