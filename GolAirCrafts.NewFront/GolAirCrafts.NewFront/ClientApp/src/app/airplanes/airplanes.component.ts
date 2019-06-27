import { Component } from '@angular/core';

@Component({
  selector: 'app-airplanes-component',
  templateUrl: './airplanes.component.html'
})
export class AirplanesComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
