import { Component } from '@angular/core';

@Component({
  selector: 'app-airplanes-editar-component',
  templateUrl: './airplanes-editar.component.html'
})
export class AirplanesEditarComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
