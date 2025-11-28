import { Component, computed, input, output, } from '@angular/core';

@Component({
  selector: 'app-button-component',
  imports: [],
  templateUrl: './button-component.html',
  styleUrl: './button-component.css'
})
export class ButtonComponent {
  //#region Inputs
  size = input<'sm' | 'md' | 'lg'>("md");
  disabled = input<boolean>(false);
  action = input<'default' | 'back' | 'search' | 'link' | 'cancel' | 'save' | 'create' | 'update' | 'add' | 'delete' | 'close' | 'login' | 'signup'>('default');
  type = input<'button' | 'submit' | 'reset'>('button');
  class = input<string>('');
  hasIcon = input<boolean>(false);
  //#endregion
  //#region Outputs
  //#endregion
  //#region computed
  color = computed(() =>
    this.action() === 'cancel' || this.action() == 'search' || this.action() === 'back' || this.action() === 'add' || this.action() === 'login' ? '2' :
      this.action() === 'signup'  ? '1' :
        this.action() === "create" ||this.action() === 'save'|| this.action() === 'update'?'3':
          this.action() === 'delete' ? 'd' :
          '')
  //#endregion

}
