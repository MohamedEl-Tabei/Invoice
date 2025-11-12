import { Component, computed, input, output, } from '@angular/core';

@Component({
  selector: 'app-button-component',
  imports: [],
  templateUrl: './button-component.html',
  styleUrl: './button-component.css'
})
export class ButtonComponent {
  //#region Inputs
  text = input<string>();
  size = input<'sm' | 'md' | 'lg'>('md');
  disabled = input<boolean>(false);
  action = input<'default'|'back' | 'link' | 'cancel' | 'save' | 'create' | 'update' | 'add' | 'delete' | 'close' | 'login' | 'signup'>('default');
  type = input<'button' | 'submit' | 'reset'>('button');
  class = input<string>('');
  hasIcon = input<boolean>(false);
  //#endregion
  //#region Outputs
  click = output<Event>();
  //#endregion
  //#region computed
  color = computed(() =>
    this.action() === 'cancel'||this.action() === 'back' || this.action() === "create" || this.action() === 'add' || this.action() === 'login' ? '2' :
      this.action() === 'save' || this.action() === 'signup' || this.action() === 'update' ? '1' :
        this.action() === 'delete' ? 'd' :
          '')
  //#endregion
  onClick(event: Event) {
    if (this.type() != 'submit') event.preventDefault();
    this.click.emit(event);
  }
}
