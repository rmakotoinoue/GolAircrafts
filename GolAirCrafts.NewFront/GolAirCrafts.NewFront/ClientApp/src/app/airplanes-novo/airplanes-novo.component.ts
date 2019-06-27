import { Component } from '@angular/core';

@Component({
  selector: 'app-airplanes-novo-component',
  templateUrl: './airplanes-novo.component.html'
})
export class AirplanesNovoComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
