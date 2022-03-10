<?php


namespace app\admin\controller;


class Cart extends Base
{
    public function index()
    {
        if (request()->isAjax()) {
            $get = $this->request->get();
            $limit = $get['limit'] ?? 10;
            $list = db('cart')
                ->where('uid', session('user_id'))
                ->join('goods','cart.gid=goods.goods_id','left')
                ->paginate($limit)
                ->toArray();
            return $this->showList($list);
        } else {
            return view();
        }
    }


    public function cartDel()
    {
        $id=input('post.cart_id');
        db('cart')->delete($id);
        return $this->success('删除成功！');
    }

    public function type()
    {
        return view();
    }
    public function typeData()
    {
        $list = db('book_type')->select();
        return $this->showAll($list);
    }
}