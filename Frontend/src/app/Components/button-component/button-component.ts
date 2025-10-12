import { Component, computed, input, output, } from '@angular/core';
import { IconBtn } from '../../Types/TIcon';

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
  action = input<'default' | 'link' | 'cancle' | 'save' | 'update' | 'add' | 'delete' | 'close'>('default');
  type = input<'button' | 'submit' | 'reset'>('button');
  class = input<string>('');
  hasIcon = input<boolean>(false);
  //#endregion
  //#region Outputs
  click = output<Event>();
  //#endregion
 //#region computed
  color = computed(() =>
    this.action() === 'cancle' || this.action() === 'add' ? '2' :
      this.action() === 'save' || this.action() === 'update' ? '1' :
        this.action() === 'delete' ? 'd' :
          '')
//#endregion
  onClick(event: Event) {
    event.preventDefault();
    if (!this.disabled) this.click.emit(event);
  }
}
