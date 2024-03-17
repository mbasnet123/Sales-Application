import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesTransactionListComponent } from './sales-transaction-list.component';

describe('SalesTransactionListComponent', () => {
  let component: SalesTransactionListComponent;
  let fixture: ComponentFixture<SalesTransactionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalesTransactionListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalesTransactionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
