import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportbyuserComponent } from './reportbyuser.component';

describe('ReportbyuserComponent', () => {
  let component: ReportbyuserComponent;
  let fixture: ComponentFixture<ReportbyuserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportbyuserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportbyuserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
