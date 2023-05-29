namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgLevelSelection :Entity,IAwake,IUILogic
	{

		public DlgLevelSelectionViewComponent View { get => this.Parent.GetComponent<DlgLevelSelectionViewComponent>();} 

		 

	}
}
