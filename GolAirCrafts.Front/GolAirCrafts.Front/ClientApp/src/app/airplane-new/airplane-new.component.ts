import { Airplane } from './../../models/airplane';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-airplane-new',
  templateUrl: './airplane-new.component.html',
  styleUrls: ['./airplane-new.component.scss']
})
export class AirplaneNewComponent implements OnInit {

  airplaneForm: FormGroup;
  code: number;
  numberPassengers: number;
  model: string;
  isLoadingResults = false;

  constructor(private router: Router, private api: ApiService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.airplaneForm = this.formBuilder.group({
      code : [null, Validators.required],
      numberPassengers : [null, Validators.required],
      model : [null, Validators.required]
    });
  }

  addAirplane(airplane: Airplane) {
    this.isLoadingResults = true;
    this.api.addAirplane(airplane)
      .subscribe(res => {
          // const id = res.id;
          this.isLoadingResults = false;
          this.router.navigate(['/airplanes']);
        }, (err) => {
          console.log(err);
          this.isLoadingResults = false;
        });
  }

}
