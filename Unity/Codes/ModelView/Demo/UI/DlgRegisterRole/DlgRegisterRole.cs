namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRegisterRole :Entity,IAwake,IUILogic
	{

		public DlgRegisterRoleViewComponent View { get => this.Parent.GetComponent<DlgRegisterRoleViewComponent>();} 

		 

	}
}
