import { Airplane } from './../../models/airplane';
import { ApiService } from './../api.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-airplanes',
  templateUrl: './airplanes.component.html',
  styleUrls: ['./airplanes.component.scss']
})


export class AirplanesComponent implements OnInit {

  displayedColumns: string[] = [ 'code', 'model', 'detalhe'];
  dataSource: Airplane[];
  isLoadingResults = true;

  constructor(private _api: ApiService) { }

  ngOnInit() {

    this._api.getAirplanes()
    .subscribe(res => {
      this.dataSource = res;
      console.log(this.dataSource);
      this.isLoadingResults = false;
    }, err => {
      console.log(err);
      this.isLoadingResults = false;
    });
  }

}
