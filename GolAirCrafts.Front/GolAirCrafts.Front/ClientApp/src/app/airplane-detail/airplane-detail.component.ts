import { Airplane } from './../../models/airplane';
import { ApiService } from './../api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-airplane-detail',
  templateUrl: './airplane-detail.component.html',
  styleUrls: ['./airplane-detail.component.scss']
})
export class AirplaneDetailComponent implements OnInit {

  airplane: Airplane = { id: null, creationDate: null, code: null, numberPassengers: null, model: '' };
  isLoadingResults = true;

  constructor(private router: Router, private route: ActivatedRoute, private api: ApiService) { }

  ngOnInit() {
    this.getAirplane(this.route.snapshot.params.id);
  }

  getAirplane(id: number) {
    this.api.getAirplane(id)
      .subscribe(data => {
        this.airplane = data;
        console.log(this.airplane);
        this.isLoadingResults = false;
      });
  }

  deleteAirplane(id: number) {
    this.isLoadingResults = true;
    this.api.deleteAirplane(id)
      .subscribe(res => {
          this.isLoadingResults = false;
          this.router.navigate(['/airplanes']);
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        }
      );
  }
}
