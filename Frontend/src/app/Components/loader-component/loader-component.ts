import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-loader-component',
  imports: [],
  templateUrl: './loader-component.html',
  styleUrl: './loader-component.css'
})
export class LoaderComponent {
  @Input({required:true})
  type:"card" = "card";
}
