export class Tenant extends Base {
  public firstName: string;
  public lastName: string;
  public jobTitle: string;
  public phoneNumber: string;
  public nationality: string;
  public tenancyStartDate: Date;
  public notes: Array<Note>;
}

export class Note extends Base{
  public description: string;
}
