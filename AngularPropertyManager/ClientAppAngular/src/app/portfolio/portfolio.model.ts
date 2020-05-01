import { IUser } from "../../api-authorization/authorize.service";
import { Property } from "../property/property.model";
import { Base } from "../base.model";

export class Portfolio extends Base {
  public name: string;
  public owner: IUser;
  public properties: Array<Property>;
}
