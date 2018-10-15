import * as React from 'react';
import './FormInput.css';

const formInput: any = (props: any) => {
    const defaultInputClass = 'form-input form-control';
    const errorInputClass = props.ErrorMessage ? ' input-error' : '';
    return (
        <div className="form-input-container form-group col-xs-12">
            <label className="form-label" htmlFor={props.InputId}>
                {props.InputLabel}
            </label>
            <input className={(props.InputClassName ? props.InputClassName : "") + defaultInputClass + errorInputClass}
                 maxLength={props.maxlength || null}
                id={props.InputId}
                name={props.name}
                type={props.InputType}
                onChange={props.changed}
                value={props.value}
                onFocus={props.focus}
                readOnly={props.readonly}
            />
            <div className="form-error">{props.ErrorMessage}</div>
        </div>
    )
}

export default formInput;